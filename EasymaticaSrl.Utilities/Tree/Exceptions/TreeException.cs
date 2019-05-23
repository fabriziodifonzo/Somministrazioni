using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace EasymaticaSrl.Utilities.Tree.Exceptions
{
    [Serializable]
    public class TreeException : Exception
    {

        public string ResourceReferenceProperty { get; set; }

        public TreeException()
        {
        }

        public TreeException(int errorCode, string message)
            : base(message)
        {
            _errorCode = errorCode;
        }

        public TreeException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected TreeException(SerializationInfo info, StreamingContext context)
                    : base(info, context)
        {
            ResourceReferenceProperty = info.GetString("ResourceReferenceProperty");
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }

            info.AddValue("ResourceReferenceProperty", ResourceReferenceProperty);
            base.GetObjectData(info, context);
        }

        public int ErrorCode
        {
            get
            {
                return _errorCode;
            }
        }

        readonly int _errorCode = -1;
    }
}
