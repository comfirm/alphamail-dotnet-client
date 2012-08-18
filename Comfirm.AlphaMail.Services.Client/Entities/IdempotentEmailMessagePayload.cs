/*
The MIT License

Copyright (c) 2011 Comfirm <http://www.comfirm.se/>

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
*/

using System.Diagnostics;
using Comfirm.Services.Client.Rest.Core.Serialization;

namespace Comfirm.AlphaMail.Services.Client.Entities
{
    [DebuggerDisplay("OperationId={OperationId}, ProjectId = {ProjectId}, From = (Name = {SenderName}, Email = {SenderEmail}), To = (Id = {ReceiverId}, Name = {ReceiverName}, Email = {ReceiverEmail})")]
    public class IdempotentEmailMessagePayload
    {
        /// <summary>
        /// Identifies this message operation. Remember that a message queued with this ID can only be sent once.
        /// </summary>
        public string OperationId { get; set; }

        /// <summary>
        /// Id of email project in Alpha Mail
        /// </summary>
        public int ProjectId { get; set; }

        /// <summary>
        /// Optional external receiver id (id of sender in your system)
        /// </summary>
        public long ReceiverId { get; set; }

        /// <summary>
        /// Name of the sender
        /// </summary>
        public string SenderName { get; set; }

        /// <summary>
        /// Email of the sender
        /// </summary>
        public string SenderEmail { get; set; }

        /// <summary>
        /// Name of the receiver
        /// </summary>
        public string ReceiverName { get; set; }

        /// <summary>
        /// Email of the receiver
        /// </summary>
        public string ReceiverEmail { get; set; }

        /// <summary>
        /// Serialized data used to render newsletter
        /// </summary>
        public string Body
        {
            get
            {
                return this._body;
            }
            set
            {
                this._body = value ?? "";
            }
        }

        private string _body = "";

        public IdempotentEmailMessagePayload() {}

        public IdempotentEmailMessagePayload(string operationId, int projectId, long receiverId, EmailContact receiver, EmailContact sender, object body)
        {
            this.SetOperationId(operationId);
            this.SetProjectId(projectId);
            this.SetReceiverId(receiverId);
            this.SetReceiver(receiver);
            this.SetSender(sender);
            this.SetBodyObject(body);
        }

        public IdempotentEmailMessagePayload SetOperationId(string operationId)
        {
            this.OperationId = operationId;
            return this;
        }

        public IdempotentEmailMessagePayload SetProjectId(int projectId)
        {
            this.ProjectId = projectId;
            return this;
        }

        public IdempotentEmailMessagePayload SetReceiverId(long receiverId)
        {
            this.ReceiverId = receiverId;
            return this;
        }

        public IdempotentEmailMessagePayload SetReceiver(EmailContact receiver)
        {
            this.ReceiverName = receiver.Name;
            this.ReceiverEmail = receiver.Email;
            return this;
        }

        public IdempotentEmailMessagePayload SetSender(EmailContact sender)
        {
            this.SenderName = sender.Name;
            this.SenderEmail = sender.Email;
            return this;
        }

        public IdempotentEmailMessagePayload SetBodyObject<TObject>(TObject source)
            where TObject : class
        {
            this.Body = new JsonWebSerializer().Serialize(source);
            return this;
        }
    }
}