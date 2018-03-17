#region License

// Copyright (c) 2013, EventDay
// All rights reserved.
//
// Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
//
// Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
// Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

#endregion License

using InfusionSoft;
using InfusionSoft.Tables;
using System;

namespace Sample
{
    internal class Program
    {
        private static void Main()
        {
             LegacyAuth();
//            OAuth();
        }

        private static void OAuth()
        {
            const string application = "YOUR APPLICATION NAME HERE";
            const string accessToken = "YOUR OAUTH 2 ACCESS_TOKEN HERE";

            var customer = new OAuthCustomer(application, accessToken);
            var client = customer.Connect();

            var users = client.DataService.Query<User>();

            var currentUser = client.DataService.GetUserInfo();

            Console.Out.WriteLine("done");
            Console.ReadLine();
        }

        private static void LegacyAuth()
        {
            const string application = "eventday";
            const string apiKey = "2d1e9b4b0d18f0d7471577b32366fb0b";

            var vendor = new Vendor(apiKey);

            var client = vendor.Connect(application, "josh.vorves@eventday.com", "jtMZ4B3C0EDt");
            
//            var customer = new Customer(application, apiKey);
//            var client = customer.Connect();
//
//            client.MethodListener = new ConsoleMethodListener();

            //UPDATE a contact
            Console.Out.WriteLine(client.ContactService.Update(105, setter =>
                {
                    setter.Set(c => c.FirstName, "Joe");
                    setter.Set(c => c.LastName, "Bobertson");
                }));

            //Find contacts dotnet style
            const string email = "chris.martin@eventday.com";
            var contacts = client.ContactService.FindByEmail(email, p => p.Include(c => c.Id)
                                                                          .Include(c => c.Email));

            //Find contact vanilla api style
            var contacts2 = client.ContactService.FindByEmail(email, new[] { "Id", "Email" });

            foreach (Contact contact in contacts)
            {
                //optin
                client.EmailService.OptIn(contact.Email, "soup for me!");
            }

            Console.Out.WriteLine("done");
            Console.ReadLine();
        }
    }
}
