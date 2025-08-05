namespace final_project.Data;
using final_project.Models;
using final_project.Interfaces;
using System.Linq;


public class TeamMemberContextDAO : ITeamMember
{
    public TeamMemberContext _context;

    public TeamMemberContextDAO(TeamMemberContext context)
    { 
        _context = context;
    }

    public TeamMember? GetTeamMember(int? id)
    {
        return _context.TeamMembers.Where(x => x.Id.Equals(id)).FirstOrDefault();
    }

    public List<TeamMember> First5Members()
    {
        return _context.TeamMembers.Take(5).ToList();
    }

    public int? AddTeamMember(TeamMember member)
    {
        try
        {
            _context.TeamMembers.Add(member);
            _context.SaveChanges();
            return 1;
        }
        catch (Exception)
        {
            return 0;
        }
    }

    public int? DeleteTeamMember(int id) 
    { 
        var member = this.GetTeamMember(id);
        
        if (member == null) 
            return null;

        try
        {
            _context.TeamMembers.Remove(member);
            _context.SaveChanges();
            return 1;
        }
        catch (Exception) 
        {
            return 0;
        }
    }

    public int? UpdateTeamMember(TeamMember member) 
    {
        var MemberToUpdate = this.GetTeamMember(member.Id);
        if (MemberToUpdate == null) 
            return null;

        MemberToUpdate.TeamMemberFullName = member.TeamMemberFullName;
        MemberToUpdate.BirthDay           = member.BirthDay;  
        MemberToUpdate.CollegeProgram     = member.CollegeProgram;
        MemberToUpdate.BirthDay           = member.BirthDay;

        try
        {
            _context.TeamMembers.Update(MemberToUpdate);
            _context.SaveChanges();
            return 1;
        }
        catch (Exception) 
        {
            return 0;
        }
    }
}