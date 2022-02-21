# POC_EmployeeOfficeDistanceChecker
Check distance and time consumption in public transportation between two given addresses and a list of adresses using google distance matrix API

#Use
Just copy the csv file with all the adresses you want to compare the distance/time consuption in the defined PATH with the desire import and export name, and set the OldAdress and NewAdress Const.

#Import Format (columns)

CompanyArea*|Adress|Postal Code|City|State|OfficeIdentifier*

*Both fields can be empty, but columns are needed

#Export Format (columns)

GivenAddress|ProcesedAddress|TimeAddressToOldRoute|TimeAddressToNewRoute|TimeAddressFromOldRoute|TimeAddressFromNewRoute|IsActualRouteFaster?|IsActualRouteShorter?
