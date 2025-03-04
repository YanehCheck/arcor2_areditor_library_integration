using System;
using System.Collections.Generic;
using Arcor2.ClientSdk.Communication;

namespace Base {
    public class RequestFailedException : Arcor2ConnectionException {
        public RequestFailedException() : base() { }
        public RequestFailedException(string message) : base(message) { }
        public RequestFailedException(List<string> messages) : base(messages.Count > 0 ? messages[0] : "") { }
        public RequestFailedException(string message, Exception inner) : base(message, inner) { }
    }

    public class ItemNotFoundException : Exception {
        public ItemNotFoundException() : base() { }
        public ItemNotFoundException(string message) : base(message) { }
        public ItemNotFoundException(List<string> messages) : base(messages.Count > 0 ? messages[0] : "") { }
        public ItemNotFoundException(string message, Exception inner) : base(message, inner) { }
    }


}
