# Server side (Attacker)
## API System
Build a FLASK API that’ll serve what actions the RAT need to preform and how often the RAT will check the API(1).
## GUI Interface
Serve the attacker to execute general and specific WMI Queries.
## DB Structure
### Tables
1. Clients
2. WMIActions
3. Client_WMIActions - Association table
Client can have many WMIActions and WMIAction can have many Clients – Many to Many relasionship (2):
![client_wmiaction_association_table.png](client_wmiaction_association_table.png)

## References
- https://blog.miguelgrinberg.com/post/the-flask-mega-tutorial-part-xxiii-application-programming-interfaces-apis
- https://blog.miguelgrinberg.com/post/the-flask-mega-tutorial-part-viii-followers