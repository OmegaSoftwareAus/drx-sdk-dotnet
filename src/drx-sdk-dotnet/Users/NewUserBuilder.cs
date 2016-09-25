#region copyright
// Copyright 2016 Digital Receipt Exchange Limited
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// 
#endregion
namespace Net.Dreceiptx.Users
{
    public class NewUserBuilder
    {
        private NewUser _newUser;

        public NewUserBuilder(string email)
        {
            _newUser = new NewUser();
            _newUser.setUserEmail(email);
        }

        public NewUserBuilder AddEmailIdentifier(string identifier)
        {
            _newUser.addIdentifier(UserIdentifierType.EMAIL, identifier);
            return this;
        }

        public NewUserBuilder AddConfigEndpointId(string optionValue)
        {
            _newUser.addConfigOption(UserConfigOptionType.ENDPOINTID, optionValue);
            return this;
        }

        public NewUser Create()
        {
            return _newUser;
        }

    }
}