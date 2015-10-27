// Copyright (c) Microsoft. All rights reserved. 
// Licensed under the MIT license. See LICENSE file in the project root for full license information. 

using System;
using System.Collections.Generic;

namespace PowerBIDotNet
{
    /// <summary>
    /// Represents an implementation of <see cref="IGroups"/>
    /// </summary>
    public class Groups : IGroups
    {
        Token _token;
        ICommunication _communication;

        /// <summary>
        /// Initializes an instance of <see cref="Groups"/>
        /// </summary>
        /// <param name="token"><see cref="Token">Access token</see></param>
        /// <param name="communication"><see cref="ICommunication"/> for communicating with Power BI</param>
        public Groups(Token token, ICommunication communication)
        {
            _token = token;
            _communication = communication;
        }

        public IEnumerable<Group> GetAll()
        {
            var groups = _communication.Get<GroupsWrapper>(_token, "groups");
            return groups.Value;
        }
    }
}
