using System;
using System.Collections.Generic;
using System.Text;

namespace OfficeDistanceChecker.Const
{
    public class ConfigConst
    {
        //IMPORT/EXPORT FILES
        public const string Path = @"C:\";//Import/Export file path
        public const string ExportFile = @"EmployeeDistance.csv";//Export file name
        public const string ImportFile = @"EmployeeAddress.csv";//Import file name

        //DISTANCE SEARCH CONST
        public const string TimeToDestination = "1641193200"; // Time TO destination
        public const string TimeFromDestination = "1641231000";//Time FROM destination
        public const string OldAddress = "";//Origin address 
        public const string NewAddress = "";//Destination Adress

        //PRINT CONFIG
        public const string Headers = "Origen  Empleado;Origen Procesado;Tiempo Ida Ruta Actual;Tiempo Ida Ruta Nueva;Tiempo Vuelta Ruta Actual;Tiempo Vuelta Ruta Nueva;Ruta actual mas rapida?;Ruta actual mas corta?";
        public const string Format = "{0};{1};{2};{3};{4};{5};{6};{7};";
        public const int FileEncodeExport = 28591;  // iso-8859-1 -->  https://docs.microsoft.com/en-us/windows/win32/intl/code-page-identifiers?redirectedfrom=MSDN
        public const int FileEncodeImport = 28591;  // iso-8859-1
    }
}
