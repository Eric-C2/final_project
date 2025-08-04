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

    public List<TeamMember> GetAllMembers()
    {
        return _context.TeamMembers.ToList();
    }

    public TeamMember? GetTeamMemberById(int id)
    {
        return _context.TeamMembers.Where(x => x.Id.Equals(id)).FirstOrDefault();
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

    public int? RemoveTeamMemberById(int id) 
    { 
        var member = this.GetTeamMemberById(id);
        if (member == null) return null;
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

    public int? UpdateMember(TeamMember member) 
    {
        var MemberToUpdate = this.GetTeamMemberById(member.Id);
        if (MemberToUpdate == null) 
            return null;

        MemberToUpdate = member;
        try
        {
            _context.TeamMembers.Update(member);
            _context.SaveChanges();
            return 1;
        }
        catch (Exception) 
        {
            return 0;
        }
    }

    
}