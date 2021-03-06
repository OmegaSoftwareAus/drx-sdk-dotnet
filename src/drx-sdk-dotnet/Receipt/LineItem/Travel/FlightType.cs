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
using Net.Dreceiptx.Users;

namespace Net.Dreceiptx.Receipt.LineItem.Travel
{
    public enum FlightType
    {
        [DrxEnumExtendedInformation("FLT0000", "Flight")]
        [EnumMember(Value = "FLT0000")]
        DEFAULT,

        [DrxEnumExtendedInformation("FLT0001", "Commercial")]
        [EnumMember(Value = "FLT0001")]
        COMMERCIAL,

        [DrxEnumExtendedInformation("FLT0002", "Private")]
        [EnumMember(Value = "FLT0002")]
        PRIVATE
    }
}
