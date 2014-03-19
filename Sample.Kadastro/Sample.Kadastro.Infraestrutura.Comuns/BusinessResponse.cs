using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sample.Kadastro.Infraestrutura.Comuns
{
    public class BusinessResponse<T>
    {
        #region Members

        public T Response { get; set; }

        public string Message
        {
            get
            {
                return Messages.FirstOrDefault();
            }

            set
            {
                Messages.Add(value);
            }
        }

        public List<string> Messages { get; set; }

        #endregion

        #region Constructors

        public BusinessResponse()
        {
            Messages = new List<string>();
        }

        public BusinessResponse(T response)
            : this()
        {
            Response = response;
        }

        public BusinessResponse(T response, string message)
            : this(response)
        {
            Message = message;
        }

        public BusinessResponse(T response, IEnumerable<string> messages)
            : this(response)
        {
            Messages.AddRange(messages);
        }

        #endregion
    }
}
