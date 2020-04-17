Exception Handling
Exception handling should be done and depending upon resources it should be logged on file or pushed on some db.
It should be thrown with customized method that someerror has occured. In this way errors on live site are tracked.

Security
Security is the key component. Not only we should be securing the messaging medium json, we should be using https
and be implementing ssl pinning to secure all request. We need to secure our db, apps from man in the middle attacks, 
ddos by using cloudfare.

API Documentation
We can use swagger that will be more helpful where users can test run the services with documentation provided.

Testing
Another key feature for the app. we should be manually testing all the use cases and if time permits should go for automation as much as possible.

Logging
Logging is the key feature where we can trace users what they were doing on site and what kind of data or parameters or session are going on the website. 
another key feature with error handling could be maintained on files or some equivalent platform like elasticsearch.

FaultTolerance
using eventsourcing we can implement fault tolerance mechanism into our api/application where we can create 
events from code that can be tracked back.

Scale
We can scale api/applications using docker/kubernetes on a fly. using webserver like nginx that can also act as load balancer/reverse proxy we 
can easily upscale or downscale api/apps on the fly.

Performance
Performance Indicators are key factors specially for api. We have different performance monitor tools available on VSTS Enterprise edition that can be help
increase the application performance.

Maintainability
Using good design patterns we can have good code / site maintainability. Short Code, Small Features or modular approach within your code is helpful to maintain our code.
Not to forget if we can implement Seperation Of Concern in our project by including different projects for different functionalities can help us maintain the code in better way.
