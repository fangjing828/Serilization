﻿//  --------------------------------------------------------------------------------------------------------------------
// <copyright file="AppendEntriesAck.cs" company="Cyrille DUPUYDAUBY">
//   Copyright 2013 Cyrille DUPUYDAUBY
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
//  --------------------------------------------------------------------------------------------------------------------
namespace Raft.Messages
{
    /// <summary>
    /// Response Message for append entries.
    /// </summary>
    public class AppendEntriesAck
    {
        private readonly string nodeId;

        private long term;

        private bool success;

        /// <summary>
        /// Initializes a new instance of the <see cref="AppendEntriesAck" /> class.
        /// </summary>
        /// <param name="nodeId">The node id.</param>
        /// <param name="term">The term.</param>
        /// <param name="success">if set to <c>true</c> [success].</param>
        public AppendEntriesAck(string nodeId, long term, bool success)
        {
            this.term = term;
            this.success = success;
            this.nodeId = nodeId;
        }

        /// <summary>
        /// Gets the node id.
        /// </summary>
        /// <value>
        /// The node id.
        /// </value>
        public string NodeId
        {
            get
            {
                return this.nodeId;
            }
        }

        /// <summary>
        /// Gets or sets the term.
        /// </summary>
        /// <value>
        /// The term.
        /// </value>
        public long Term
        {
            get
            {
                return this.term;
            }

            set
            {
                this.term = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="AppendEntriesAck"/> is success.
        /// </summary>
        /// <value>
        ///   <c>true</c> if success; otherwise, <c>false</c>.
        /// </value>
        public bool Success
        {
            get
            {
                return this.success;
            }

            set
            {
                this.success = value;
            }
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return string.Format("AppendEntriesAck: NodeId: {0}, Term: {1}, Success: {2}", this.nodeId, this.term, this.success);
        }
    }
}