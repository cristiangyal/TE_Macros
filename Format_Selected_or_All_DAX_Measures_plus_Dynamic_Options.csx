

// Title: Format Selected or All DAX Measures (plus Dynamic Options)
// Author: Cristian Angyal, 
//         twitter.com/cristian_angyal
//         https://www.linkedin.com/in/cristian-angyal/
//
//Script working in both TE2 (free) and TE3!
//
// This script, when executed, will loop through all selected measures (or all measures in the model if checked in Options)
// and format DAX Expressions offering the possibility to choose Short or Long-line DAX formatting (default is long-line format),
// optionally insert a LineBreak on first line (default is not included) and optionally add DAX  Expression as Description (default is not included)
//
// When finished formatting an Info message appears on screen with a summary of what was executed: the total number of Measures formated, measure(s) name(s) listed,
// and any other option checked plus the confirmation when Script is Executed Succesfully!
// ====================================================================================================================================

//Options Start

var _sMeasures = Selected.Measures;      //Switch <<Selected.Measures>> to << Model.AllMeasures>> to format ALL DAX measures in the Model
var _useShortFormatDAX = false;          //Switch to <<true>> for using Short Format DAX for selected measures
var _insertLineBreakOnFirstLine = false; //Switch to <<true>> for adding a break line between Measure Name and DAX Formula
var _addDAXToDescription = false;        //Switch to <<true>> for adding the DAX Expression as a Description of the Measure
var _SpaceAfterFunctionName = false;     //Switch to <<true>> to insert a space after DAX function Name

//Options End


string _smNames = ""; 
string _textShortFormatDAX = "";
string _textLineBreakonFirstLine = "";
string _textDAXDescriptionAdded = "";
string _ScriptResults="";
int _MeasuresCount;

// Loop through each selected measure to format DAX and collect Measure Names
foreach (var m in _sMeasures) {
  FormatDax(m);
  CallDaxFormatter(shortFormat : _useShortFormatDAX, skipSpaceAfterFunctionName: !_SpaceAfterFunctionName);
 
//Check whether Short Format DAX is enabled and get the details for Info Message  
if (_useShortFormatDAX) {
    {      _textShortFormatDAX = "\n\n"+"DAX Short Format Used!";    }
  };

//Check whether a Line Break is enabled and get the details for Info Message
 if (_insertLineBreakOnFirstLine) {
    {      m.Expression = "\r\n" + m.Expression;    }
    { _textLineBreakonFirstLine = "\n" +"Line Break added after first line!"; }
  }

//Check whether a DAX Expression in Description is enabled and get the details for Info Message
  if (_addDAXToDescription) {
    {      m.Description = m.Expression;    }
    { _textDAXDescriptionAdded = "\n" + "DAX Expression(s) added as Description for selected measures!"; }
  }
  
//Get the Measure names for Info Message
  _smNames = _smNames + "\n     " + m.Name; 
  
}

//Count the number of Measures affected
_MeasuresCount = _sMeasures.Count();

//Based on number of measures affected prepare the details for Info Message
  if ( _MeasuresCount == 0) {
    {_ScriptResults = "No DAX Measures affected ⚠" +
     "\n" + " ---------------------------------" + 
     "\n" + "Please make sure you EITHER have at least one Measure selected"+
     "\n" + "OR Model.AllMeasures is assigned to _sMeasures in Script Options to format ALL measures in the model "; ;    }
  }
 else 
{
    {_ScriptResults =  "DAX was formatted for " + Convert.ToString(_sMeasures.Count()) + " measures! \n\n" +
"Measures affected: " + Convert.ToString(_smNames) + 
       _textShortFormatDAX +
      _textLineBreakonFirstLine + 
      _textDAXDescriptionAdded + 
     "\n" + " ---------------------------------" + 
     "\n" + "Script finished succesfully!";   }
  };

// Display in an Info Message summary for what was executed: number of formatted measures, their names and optional additional operations performed
Info( _ScriptResults );
