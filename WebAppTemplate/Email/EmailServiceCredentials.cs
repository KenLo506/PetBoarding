using System.Configuration;
using System.Net.Mail;
using System.Net;
using System;

 public static class EmailServiceCredentials
{
    public static string EmailSMTPUrl { get; private set; }
    public static int PortNumber { get; private set; }
    public static string EmailSMTPUserNameHash { get; private set; }
    public static string EmailSMTPPasswordHash { get; private set; }
    public static string EmailFromAddress { get; private set; }
    public static string EmailFromName { get; private set; }
    public static string EmailAppName { get; private set; }

    public static void SetCredentials(string emailSMTPUrl, int portNumber, string emailSMTPUserNameHash, string emailSMTPPasswordHash, string emailFromAddress, string emailFromName, string emailAppName)
    {
        EmailSMTPUrl = emailSMTPUrl;
        PortNumber = portNumber;
        EmailSMTPPasswordHash = emailSMTPPasswordHash;
        EmailSMTPUserNameHash = emailSMTPUserNameHash;
        EmailFromAddress = emailFromAddress;
        EmailFromName = emailFromName;
        EmailAppName = emailAppName;


    }

    //Call from global application
    public static void PopulateEmailCredentialsFromAppConfig()
    {
        string emailSMTPURL = ConfigurationManager.AppSettings["emailSMTPURL"].ToString();
        int portNumber = int.TryParse(ConfigurationManager.AppSettings["portNumber"], out int parsedPort) ? parsedPort : 587;
        string emailSMTPUserNameHash = ConfigurationManager.AppSettings["emailSMTPUserNameHash"].ToString();
        string emailSMTPPasswordHash = ConfigurationManager.AppSettings["emailSMTPPasswordHash"].ToString();
        string emailFromAddress = ConfigurationManager.AppSettings["emailFromAddress"].ToString();
        string emailFromName = ConfigurationManager.AppSettings["emailFromName"].ToString();
        string emailAppName = ConfigurationManager.AppSettings["emailAppName"].ToString();

        SetCredentials(emailSMTPURL, portNumber, emailSMTPUserNameHash, emailSMTPPasswordHash, emailFromAddress, emailFromName, emailAppName);
    }

}