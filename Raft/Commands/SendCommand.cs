﻿//  --------------------------------------------------------------------------------------------------------------------
// <copyright file="SendCommand.cs" company="Cyrille DUPUYDAUBY">
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
namespace Raft.Commands
{
    /// <summary>
    /// Command to send to the state machine.
    /// </summary>
    /// <typeparam name="T">Type of the command.</typeparam>
    public class SendCommand<T>
    {
        #region fields

        private readonly T command;

        private string id;

        private long identifier;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="SendCommand{T}"/> class.
        /// </summary>
        /// <param name="command">The command.</param>
        public SendCommand(T command)
        {
            this.command = command;
        }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public long Identifier
        {
            get
            {
                return this.identifier;
            }
        }

        /// <summary>
        /// Gets the id.
        /// </summary>
        /// <value>
        /// The id.
        /// </value>
        public string Id
        {
            get
            {
                return this.id;
            }
        }

        /// <summary>
        /// Gets the command.
        /// </summary>
        /// <value>
        /// The command.
        /// </value>
        public T Command
        {
            get
            {
                return this.command;
            }
        }
    }   
}