using final_project.Models;

namespace final_project.Interfaces
{
    public interface ITeamMember
    {
        TeamMember? GetTeamMember(int? id);

        List<TeamMember> First5Members();

        int? AddTeamMember(TeamMember member);

        int? DeleteTeamMember(int id);

        int? UpdateTeamMember(TeamMember member);
    }
}