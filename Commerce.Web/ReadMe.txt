To Install:

1.) Running from your local machine: In IIS, set a virtual directory on Commerce.Web. 
    Running in a hosted scenario: FTP the contents of the zip folder to your site.
2.) Give the ASPNET or NETWORK SERVICE account "Modify" and "Write" access to the web.config file 
    in Commerce.Web.
3.) Browse to http://<install location>/default.aspx (something like . . . 
    http://locahost/dashcommerce/default.aspx or http://www.mysite.com/default.aspx)
4.) You should be redirected to http://<install location>/install/install.aspx . . . if not, GO THERE.
5.) Follow the installation wizard instructions. NOTE: If you are doing this in a hosted scenario, 
    then your database user account will probably NOT have the "dbCreator" rights required by the 
    installer to CREATE the database. In this case, create the database using SQL Server Management 
    Studio (an Express Edition is available for free) or, have your hosting provider create the 
    database for you. From that point, you should be able to select the database from the drop down 
    list in the installer.
6.) Please report any bugs / issues at http://www.codeplex.com/dashCommerce/WorkItem/List.aspx.
7.) You can also find help in the forums at http://www.dashcommerce.org.
8.) Please consider using dashCommerce Hosting! Details can be found at http://www.dashcommerce.org.
9.) DEVELOPERS: To open dashCommerce in Visual Studio got to File -> Open -> Web Site and browse to the Commerce.Web directory.