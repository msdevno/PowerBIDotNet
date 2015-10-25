using System;
using System.Collections.Generic;

namespace Infrastructure.PowerBI
{
    public class Groups : IGroups
    {
        Token _token;
        ICommunication _communication;

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
