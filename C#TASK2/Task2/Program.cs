using System;
using System.Collections.Generic;

// Abstract Class Member
abstract class Member
{
    public int MemberID;
    public string MemberName;
    public int MemberAge;

    public Member(int ID, string Name, int Age)
    {
        MemberID = ID;
        MemberName = Name;
        MemberAge = Age;
    }
    public abstract double calculateMonthlyFee();
    public abstract void DisplayDetails();
}

// Regular Member Class
class RegularMember : Member
{
    public double WorkOutPlanFee;
    public const double BaseFee = 50.0;
    public RegularMember(int ID, string Name, int Age, double WorkOutPlanFee) : base(ID, Name, Age)
    {
        this.WorkOutPlanFee = WorkOutPlanFee;
    }
    public override double calculateMonthlyFee()
    {
        return  BaseFee + WorkOutPlanFee;
    }
    public override void DisplayDetails()
    {
        Console.WriteLine("Member ID: {0}", MemberID);
        Console.WriteLine("Member Name: {0}", MemberName);
        Console.WriteLine("Member Age: {0}", MemberAge);
        Console.WriteLine("Monthly Fee: {0}", calculateMonthlyFee());
    }
}

// Premium Member Class
class PremiumMember : Member
{
    double PersonalTrainerFee;
    double DietPlanFee;
    public const double BaseFee = 100.0;
    public PremiumMember(int ID, string Name, int Age, double PersonalTrainerFee, double DietPlanFee) : base(ID, Name, Age)
    {
        this.PersonalTrainerFee = PersonalTrainerFee;
        this.DietPlanFee = DietPlanFee;
    }
    public override double calculateMonthlyFee()
    {
        return BaseFee + PersonalTrainerFee + DietPlanFee;
    }
    public override void DisplayDetails()
    {
        Console.WriteLine("Member ID: {0}", MemberID);
        Console.WriteLine("Member Name: {0}", MemberName);
        Console.WriteLine("Member Age: {0}", MemberAge);
        Console.WriteLine("Monthly Fee: {0}", calculateMonthlyFee());
    }
}

// Interface for Gym Management
interface IGymManagement
{
    void AddMember(Member member);
    void DisplayAllMembers();
}

// Gym Class
class Gym : IGymManagement
{
    List<Member> members = new List<Member>();
    public void AddMember(Member member)
    {
        members.Add(member);
    }
    public void DisplayAllMembers()
    {
        foreach (Member member in members)
        {
            member.DisplayDetails();
        }
    }
}

// Main Program
class Program
{
    static void Main(string[] args)
    {
        Gym gym = new Gym();
        RegularMember regularMember = new RegularMember(1, "Ahmed", 25, 20);
        RegularMember regularMember2 = new RegularMember(2, "Ali", 27, 25);
        PremiumMember premiumMember = new PremiumMember(3, "Mohamed", 30, 30, 40);
        PremiumMember premiumMember2 = new PremiumMember(4, "Omar", 35, 35, 50);
        gym.AddMember(regularMember);
        gym.AddMember(regularMember2);
        gym.AddMember(premiumMember);
        gym.AddMember(premiumMember2);
        gym.DisplayAllMembers();
    }
}