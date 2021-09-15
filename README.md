# Microsoft.SignalR.Federated
 
To configure the application, make sure to update the Domain, TenantId and ClientId in the appsettings.json file with an application in your Azure AD.

![image](https://user-images.githubusercontent.com/44238629/133316961-d5b09b08-b51c-490a-9381-d77bb754eebd.png)

The project has two tiles:

1) Link to a View with the component referencing a Hub without the Authorize attribute
2) Link to a View with the component referencing a Hub with the Authorize attribute

![image](https://user-images.githubusercontent.com/44238629/133316736-e940417a-a57c-4d54-b456-47a0766d9680.png)

After logging into the application, you will see your email address in the top-right corner. This validates the user is Authenticated and in the HttpContxt.

When you navigate to the first tile, you will see this error:

![image](https://user-images.githubusercontent.com/44238629/133317216-d5e75621-b519-411e-801e-fa0e50d0945f.png)

When you navigate to the second time, you will will not see an error. However, if you place a breakpoint on line 15 of the Hubs/SpecialMessageHub.cs, you will notice the customerId is null:

![image](https://user-images.githubusercontent.com/44238629/133317569-f022dd61-8e93-4b46-aa44-d4a4c245b8dd.png)



