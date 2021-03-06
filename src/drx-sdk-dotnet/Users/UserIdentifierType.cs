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

using System.Runtime.Serialization;

namespace Net.Dreceiptx.Users
{
    public enum UserIdentifierType
    {
        [DrxEnumExtendedInformation("GUID", "Users Global Unique Identifier")]
        [EnumMember(Value = "GUID")]
        Guid,

        [DrxEnumExtendedInformation("EMAIL", "Users primary email")]
        [EnumMember(Value = "EMAIL")]
        Email,

        //TODO: Mobile number is not part of the User object
        [DrxEnumExtendedInformation("MOBILE", "Users mobile number with country code without the +")]
        [EnumMember(Value = "MOBILE")]
        Mobile
    }
}