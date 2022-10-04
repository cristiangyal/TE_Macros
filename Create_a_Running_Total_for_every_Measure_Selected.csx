// Creates a RT measure for every selected measure .
foreach(var m in Selected.Measures) {
    var newMeasure = m.Table.AddMeasure(
    m.Name + " RT",                                       // Name
    "CALCULATE(" + m.DaxObjectName + ", FILTER(ALL('Calendar'[Date]), 'Calendar'[Date] <= MAX ( 'Calendar'[Date] )))",     // DAX expression
        m.DisplayFolder                                        // Display Folder
    );
    newMeasure.FormatString = m.FormatString;               // Copy format string from original measure
    
}


