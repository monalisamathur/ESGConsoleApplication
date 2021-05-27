# ESGConsoleApplication
ESG Console Application

Visual Studio : 2019
MySql : 8.0.25


There are two classes namely Program.cs and CustomerDetails.cs 

the class CustomerDetails contains the implementation of the class basically all the getters and setters.

the Program.cs class consists of the code where we read the file from the directory which has to be in the csv form . The data thus read from the file is comma separated. 
I have created a folder in bin named ESGData containing the file ESGData.csv. 
My file has 3-4 records to be read from.  Validating that the customerref is not null  has to be an integer. The op of the file is read in the json format.
 A call to the rest api is given by the following method restRecordData which makes a web call request and the ,method is post method. 

