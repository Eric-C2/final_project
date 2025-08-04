using final_project.Models;

namespace final_project.Interfaces
{
    public interface ITeamMember
    {

        int? AddTeamMember(TeamMember member);
        List<TeamMember> GetAllMembers();

        TeamMember? GetTeamMemberById(int id);

        int? RemoveTeamMemberById(int id);
    }
}