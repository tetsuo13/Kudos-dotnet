using Kudos.Models;
using System;
using System.Collections.Generic;

namespace Kudos
{
    /// <summary>
    /// General exception thrown by the Kudos API.
    /// </summary>
    public class KudosException : Exception
    {
        /// <summary>
        /// Gets the set of errors returned from Kudos API.
        /// </summary>
        public IEnumerable<Error> Errors { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="KudosException"/>
        /// class.
        /// </summary>
        public KudosException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KudosException"/>
        /// class.
        /// </summary>
        /// <param name="message">Error message.</param>
        public KudosException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KudosException"/>
        /// class.
        /// </summary>
        /// <param name="errorResult">Error result set from Kudos API.</param>
        /// <param name="message">Error message.</param>
        public KudosException(ErrorResponse errorResult, string message)
            : base(message)
        {
            if (errorResult.Errors != null)
            {
                Errors = errorResult.Errors;
            }
        }
    }
}
