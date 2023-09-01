# Client Side (Victim)
## Classes Management
### Query Class
Query – WQL Query (We’ll use it from the C2).
![WQL.png](WQL.png)
1) WMI Class - Win32_OperatingSystem
2) Class attributes - * 
3) “build” query function

### HTTPClient Class
Object to communicate with the C&C server
Contains client's information:
```cs
        static HttpClient client = new HttpClient();
        private string id;
        private string ipAddress;
        private string username;
        private string os;
        private string uri;
        private Status clientStatus;
```
### WMI_component Class
Handle wmi execution at runtime.
Contains the following attributes:
```cs
            this.scope = scope;
            this.wmiClass = wmi_class;
            this.wmiAttributes = wmiAttributes;
            this.query = new Query(this.scope, this.wmiAttributes, this.wmiClass);
            this.wmiActionId = wmiActionId;
```

## Features
1.	WMI Interaction
2.	Capture screenshot
3.	Keylogger
4.	Browse files
## Reference
- https://docs.microsoft.com/en-us/dotnet/api/system.management.propertydata?view=dotnet-plat-ext-6.0 – Refer to each property from the WQL execution.