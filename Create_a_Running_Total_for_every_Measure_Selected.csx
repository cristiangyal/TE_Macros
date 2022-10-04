
// Title: Create_a_Running_Total_for_every_Measure_Selected
// Author: Cristian Angyal, 
//         twitter.com/cristian_angyal
//         https://www.linkedin.com/in/cristian-angyal/
//
//Script working in both TE2 (free) and TE3!
//
// This script, when executed, will loop through all selected measures and creates a RT Measure plus it copies the "original"
// formatstring to the newly created measurefirmation when Script is Executed Succesfully!
// ====================================================================================================================================

foreach(var m in Selected.Measures) {
    var newMeasure = m.Table.AddMeasure(
    m.Name + " RT",                                       // Name
    "CALCULATE(" + m.DaxObjectName + ", FILTER(ALL('Calendar'[Date]), 'Calendar'[Date] <= MAX ( 'Calendar'[Date] )))",     // DAX expression
        m.DisplayFolder                                        // Display Folder
    );
    newMeasure.FormatString = m.FormatString;               // Copy format string from original measure
    
}


