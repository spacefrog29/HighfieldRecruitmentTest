# Highfield Recruitment Test

## Technical Requirements
### Backend
* .NET
* C#/VB
* REST API

### Frontend
* Angular/React

## List of requirements 

* Hit the following endpoint to get user data https://recruitment.highfieldqualifications.com/api/test
* Calculate the following on the user set
  * A list of each colour in the data set with the frequency of each colour, order by highest quantity then alphabetically
  * Every users age plus 20 years
* Display this information
* All object information can be found https://recruitment.highfieldqualifications.com/docs/index.html
* Provide your source code prior to your interview via GitHub or other means

## Included in the project are:

* ASP.Net Core server which pulls the api data from the Highfield API and processes it using the given data models. Once running the server presents the following JSON endpoints: https://localhost:7103/api/getAllUsers and https://localhost:7103/api/getColourList  Both Endpoints can also be tested using the Swagger interface https://localhost:7103/swagger/index.html (or via Postman)
* ASP.Net Core tests - there is only one functioning test using XUnit at the moment - Obviously I didn't stick to TDD principles but given time I would have tested the controller using MOQ
* Angular 17 front end which pulls data from the server, the app can be started using ng serve within it's root folder. Once running it will serve at an address http://localhost:4200/ opening this address in your browser should give the correct responses. The users are displayed as requested and I also put a function around the date of birth to make it read in a more pleasant (UK) format.  The list of colours are displayed in order of popularity and then in order of name.

## Issues
* I was attempting to change background colour of the colours to represent their named colour, although everything is in place and the colour list renders the correct CSS the colours are not currently showing as colours correctly. I realise this wasn't requested but it would be something I'd like to have completed again given time.
