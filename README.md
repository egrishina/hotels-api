# Web Service / API
## Assignment
Write a RESTful web service including the parameters HotelID and ArrivalDate.
The web service GET request imports the file (hotelsrates.json), filters the list
by means of the parameters and returns a filtered list.
### Input
Method: String, stream, JsonObject or file based on the file hotelsrates.json.

Browser: HotelID and ArrivalDate.
### Output
Required output format: HTTP response with a JSON string body.
## Getting Started
1. Clone the repo.
2. Run tests to make sure that the program works as expected.
3. Run the application to start the server.
4. The JSON file is already included in the project and it will be automatically located inside the folder WebService\src\WebService\Resources.
5. Use Postman or web browser to test the endpoint. Send GET request with filter parameters. For example, 

`https://localhost:7104/hotels/7294?arrivalDate=2016-03-15T00:00:00`

6. Check the output.
