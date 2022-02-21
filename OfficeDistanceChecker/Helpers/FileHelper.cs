using OfficeDistanceChecker.Const;
using OfficeDistanceChecker.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace OfficeDistanceChecker.Helpers
{
    public class FileHelper
    {
        public static void PrintResults(List<EmployeeRoute> employeeRoutes)
        {
            CreateFile();

            foreach (var eRoute in employeeRoutes)
            {
                var origin = eRoute.Origin.Replace(";", ",");
                var ProcessedOrigin = eRoute.ProcessedOrigin.Replace(";", ",");
                var oldOriDestDur = eRoute.OldRoute.OriginDestination.Duration;
                var newOriDestDur = eRoute.NewRoute.OriginDestination.Duration;
                var oldDestOriDur = eRoute.OldRoute.DestinationOrigin.Duration;
                var newDestOriDur = eRoute.NewRoute.DestinationOrigin.Duration;


                AppendLine(String.Format(ConfigConst.Format,
                   /*0*/origin,
                   /*1*/ProcessedOrigin != string.Empty ? ProcessedOrigin : "No se encuentra coincidencia",
                   /*2*/oldOriDestDur != (int?)null ? oldOriDestDur + " min" : "Sin transporte publico",
                   /*3*/newOriDestDur != (int?)null ? newOriDestDur + " min" : "Sin transporte publico",
                   /*4*/oldDestOriDur != (int?)null ? oldDestOriDur + " min" : "Sin transporte publico",
                   /*5*/newDestOriDur != (int?)null ? newDestOriDur + " min" : "Sin transporte publico",
                   /*6*/eRoute.IsOldRouteFaster,
                   /*7*/eRoute.IsOldRouteShorter));
            }


        }

        static async void CreateFile()
        {
            using StreamWriter file = new StreamWriter(ConfigConst.ExportFile, append: true, Encoding.UTF8/*Encoding.GetEncoding(ConfigConst.FileEncodeExport)*/);
            await file.WriteLineAsync(ConfigConst.Headers);
        }

        static async void AppendLine(string text)
        {
            using StreamWriter file = new StreamWriter(ConfigConst.ExportFile, append: true);
            await file.WriteLineAsync(text);
        }

        public static List<EmployeeAddress> ReadCSVFile()
        {
            var employeeLst = new List<EmployeeAddress>();


            using (var reader = new StreamReader(ConfigConst.Path + ConfigConst.ImportFile, Encoding.GetEncoding(ConfigConst.FileEncodeImport)))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');

                    var employee = new EmployeeAddress { BussinessUnit = values[0], Address = values[1], PostalCode = values[2], Town = values[3], Province = values[4], WorkCenter = values[5] };

                    employeeLst.Add(employee);
                }
            }

            return employeeLst;
        }


        public static List<string> EmployeeAddressToStringList(List<EmployeeAddress> employeeAddresses)
        {
            List<string> eStrLst = new List<string>();

            foreach (var item in employeeAddresses)
            {
                string eStr = string.Format("{0} {1} {2}", item.Address, item.PostalCode, item.Town);

                eStrLst.Add(eStr);
            }
            return eStrLst;
        }


        #region Legacy

        //public static List<string> ReadFile()
        //{

        //    List<string> _separateStringList = new List<string>();
        //    string _item = "";
        //    using (FileStream fs = File.Open(ConfigConst.Path + ConfigConst.importFile, FileMode.Open))
        //    {
        //        byte[] b = new byte[8192];
        //        UTF8Encoding temp = new UTF8Encoding(true);

        //        while (fs.Read(b, 0, b.Length) > 0)
        //        {
        //            var a = (temp.GetString(b).Split(';')).ToList();
        //            foreach (var item in a)
        //            {
        //                if (!String.IsNullOrEmpty(item))
        //                {
        //                    _item = item.Trim();
        //                    if (_item != shtxt)
        //                    {
        //                        _separateStringList.Add(_item);
        //                    }

        //                }
        //            }
        //        }
        //    }

        //    return _separateStringList;
        //}

        #endregion
    }

}
