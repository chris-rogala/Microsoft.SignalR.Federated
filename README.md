# Microsoft.SignalR.Federated
 
To configure the application, make sure to update the Domain, TenantId and ClientId in the appsettings.json file with an application in your Azure AD.

![image](https://user-images.githubusercontent.com/44238629/133316961-d5b09b08-b51c-490a-9381-d77bb754eebd.png)

The project has two tiles:

1) Link to a View with the component referencing a Hub with the Authorize attribute and Blazor
2) Link to a View with the component referencing a View with the Authorize attribute and JavaScript

![image](https://user-images.githubusercontent.com/44238629/133670019-1d918e5c-5051-4be0-8d45-fe94a5747363.png)

After logging into the application, you will see your email address in the top-right corner. This validates the user is Authenticated and in the HttpContxt.

When you navigate to the first tile, you will see this error:

![image](https://user-images.githubusercontent.com/44238629/133317216-d5e75621-b519-411e-801e-fa0e50d0945f.png)

When you navigate to the second tile, you will see this:

![image](https://user-images.githubusercontent.com/44238629/133670227-18ba67b7-6220-4242-ad0f-132216af278f.png)

When the SignalR connection is made, the connection is put into a group based on the domain of the email address. To display a message, send a call using this cURL:

    curl --location --request POST 'https://localhost:{{port}}/customers/{{domain}}/send-message' \
    --header 'Content-Type: application/json' \
    --data-raw '{
        "text": "Happy coding!!"
    }'

Once you send that message, you will see it appear in the page:

![image](https://user-images.githubusercontent.com/44238629/133671930-a1989993-3390-4567-8878-8b63e65840c5.png)

The cookie is passed from the browser. 




