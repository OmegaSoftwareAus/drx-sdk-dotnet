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

using System.Collections.Generic;
using System.Runtime.Serialization;
using Net.Dreceiptx.Receipt.Validation;

namespace Net.Dreceiptx.Receipt.Document
{
    /// <summary>
    /// Class representing the header information that must be sent with a
    /// DigitalReceipt. It includes information about the sender of the receipt,
    /// Merchant information etc
    /// </summary>
    [DataContract]
    public class StandardBusinessDocumentHeader
    {
        /// <summary> Construtor </summary>
        public StandardBusinessDocumentHeader()
        {
            Sender = new List<DocumentOwner>();
            Receiver = new List<DocumentOwner>();
            DocumentIdentification = new DocumentIdentification();
        }

        /// <summary>
        /// Gets and sets the Receiver(s) of the Digital Receipt
        /// </summary>
        [DataMember]
        public List<DocumentOwner> Receiver { get; set; }

        /// <summary>
        /// Gets and sets the Sender of the DigitalReceipt
        /// </summary>
        [DataMember]
        public List<DocumentOwner> Sender { get; set; }

        public void AddReceiver(DocumentOwner receiver)
        {
            Receiver.Add(receiver);
        }

        [DataMember]
        public DocumentIdentification DocumentIdentification { get; set; }

        public DocumentOwner MerchantGLN
        {
            get
            {
                var merchant = Sender.Find(x => x.Identifier.Authority == "GS1");
                if (merchant == null)
                {
                    merchant = new DocumentOwner();
                    merchant.Identifier.Authority = "GS1";
                    Sender.Add(merchant);
                }
                return merchant;
            }
        }


        public DocumentOwner DRxGLN
        {
            get
            {
                var dRx = Receiver.Find(x => x.Identifier.Authority == "GS1");
                if (dRx == null)
                {
                    dRx = new DocumentOwner();
                    dRx.Identifier.Authority = "GS1";
                    Receiver.Add(dRx);
                }
                return dRx;
            }
        }

        public DocumentOwner UserIdentifier
        {
            get
            {
                var user = Receiver.Find(x => x.Identifier.Authority == "dRx");
                if (user == null)
                {
                    user = new DocumentOwner();
                    user.Identifier.Authority = "dRx";
                    Receiver.Add(user);
                }
                return user;
            }
        }


        public List<ReceiptContact> ClientContacts => Receiver[1].DocumentOwnerContact;

        public void AddMerchantContact(ReceiptContact contact)
        {
            Sender[0].AddDocumentOwnerContact(contact);
        }

        public void AddRMSContact(ReceiptContact contact)
        {
            Receiver[1].AddDocumentOwnerContact(contact);
        }

        public ReceiptValidation Validate(ReceiptValidation receiptValidation)
        {
            if (Sender.Count == 0)
            {
                receiptValidation.AddError(ValidationErrors.MerchantGLNMustBeSet);
            }

            return receiptValidation;
        }
    }
}