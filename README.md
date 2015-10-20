# Maileon .NET API Client

This is the implementation of the Maileon API for .NET applications.

## Documentation
See the official [Maileon API documentation](http://dev.maileon.com/api/rest-api-1-0/?lang=en) for more information about the Maileon API.
This library attempts to implement all the features of the Maileon API as they become available. 

## Usage
The library is split into various services; these services provide a way to manipulate different parts of the API.
In most cases the path of the specific request determines the actual service that will provide that call in this library.
For example all the calls relating to transactions (/transaction/*) can be found in the MaileonTransactionsService class.

To use the Maileon API you have to provide a valid MaileonConfiguration object to the service classes. 
The configuration contains information required to properly reach and authenticate with the API server.

Currently available base URIs:
* https://adc.maileon.com/svc/ for AddressCheck
* https://api.maileon.com/1.0/ for everything else

For information about the API keys and API key privileges contact your Maileon provider.

## Credits

[Viktor Balogh](https://github.com/viktorbalog)

## License

The MIT License (MIT)

Copyright (c) 2015 Viktor István Balog

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
