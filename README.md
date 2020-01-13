# JSChatChallenge

Mandatory Features 
● Allow registered users to log in and talk with other users in a chatroom. 
● Allow users to post messages as commands into the chatroom with the following format /stock=stock_code 
● Create a decoupled bot that will call an API using the stock_code as a parameter (https://stooq.com/q/l/?s=aapl.us&f=sd2t2ohlcv&h&e=csv, here is the stock_code) 
● The bot should parse the received CSV file and then it should send a message back into the chatroom using a message broker like RabbitMQ. The message will be a stock quote using the following format: “APPL.US quote is $93.42 per share”. The post owner will be the bot. 
● Have the chat messages ordered by their timestamps and show only the last 50 messages. 
● Unit test the functionality you prefer. 
Bonus Point included 
● Use .NET identity for users authentication 
● Handle messages that are not understood or any exceptions raised within the bot. 

Notes
● The solution is prepared to be downloaded and then once builded and started will run the frontend and the bot at the same time
● .NET identity is implemented
● User messages are stored in local SQL database
● Bot messages are not stored in local SQL database
● xUnit tests cases were added for the Bot Service

Mariano
