/*
 * Copyright 2016 Digital Receipt Exchange Limited
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System.Runtime.Serialization;

namespace Net.Dreceiptx.Receipt.Serialization.Json
{
    /// <summary>
    /// Just a wrapper class for the DigitalReceiptMessage. This represents top level class that
    /// will ultimately be serialized and sent to the Exchange
    /// </summary>
    [DataContract]
    public class DigitalReceiptMessageWrapper
    {
        /// <summary>
        /// Gets and sets the DigitalReceiptMessage
        /// </summary>
        [DataMember]
        public DigitalReceipt DRxDigitalReceipt { get; set; }

        /// <summary>
        /// Serializes the message to a JSON format
        /// </summary>
        /// <returns>JSON message as a string</returns>
        public string SerializeToJson()
        {
            return JsonSerializer.SerializeToString(this);
        }

        /// <summary>
        /// Deserializes the given JSON string to a DigitalReceiptMessageWrapper instance
        /// </summary>
        /// <param name="json">The JSON to be deserialized</param>
        /// <returns></returns>
        public static DigitalReceiptMessageWrapper DeserializeFromJson(string json)
        {
            return JsonSerializer.Deserialize<DigitalReceiptMessageWrapper>(json);
        }
    }
}