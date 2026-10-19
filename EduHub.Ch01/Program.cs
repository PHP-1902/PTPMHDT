
using System;
using System.Collections.Generic;
using EduHub.Ch01.Domain;

const string Separator = "========================================";

// BƯỚC 1: Tạo CLB
Console.WriteLine(Separator);
Console.WriteLine("STEP 1: CREATE CLUB");

Club club = Club.Create(
    "Tech Club",
    "A student club for technology, programming, and AI activities.");

Console.WriteLine($"Club: {club.Name}");
Console.WriteLine($"Description: {club.Description}");
Console.WriteLine($"Club ID: {club.Id}");

// BƯỚC 2: Thêm 3 thành viên
Console.WriteLine($"\n{Separator}");
Console.WriteLine("STEP 2: ADD MEMBERS");

Member member1 = Member.Create(
    "Nguyen Van An",
    "an@example.com",
    "SV001");

Member member2 = Member.Create(
    "Tran Thi Binh",
    "binh@example.com",
    "SV002");

Member member3 = Member.Create(
    "Le Van Cuong",
    "cuong@example.com",
    "SV003");

club.AddMember(member1);
club.AddMember(member2);
club.AddMember(member3);

Console.WriteLine($"Added member: {member1.Name}");
Console.WriteLine($"Added member: {member2.Name}");
Console.WriteLine($"Added member: {member3.Name}");
Console.WriteLine($"Total members: {club.MemberCount()}");

// BƯỚC 3: Tạo sự kiện
Console.WriteLine($"\n{Separator}");
Console.WriteLine("STEP 3: CREATE EVENT");

Event techEvent = Event.Create(
    club.Id,
    "Workshop AI",
    DateTime.UtcNow.AddDays(7),
    50,
    false);

Console.WriteLine($"Event: {techEvent.Title}");
Console.WriteLine($"Date (UTC): {techEvent.Date:yyyy-MM-dd HH:mm}");
Console.WriteLine($"Capacity: {techEvent.Capacity}");
Console.WriteLine($"Online: {techEvent.IsOnline}");

// BƯỚC 4: Hai thành viên đăng ký và xác nhận
Console.WriteLine($"\n{Separator}");
Console.WriteLine("STEP 4: REGISTER AND CONFIRM");

Registration registration1 =
    Registration.Create(member1.Id, techEvent.Id);

Registration registration2 =
    Registration.Create(member2.Id, techEvent.Id);

var registrations =
    new List<(Member Member, Registration Registration)>
    {
        (member1, registration1),
        (member2, registration2)
    };

Console.WriteLine(
    $"{member1.Name} registered. Status: {registration1.Status}");

registration1.Confirm();
Console.WriteLine(
    $"{member1.Name} confirmed. Status: {registration1.Status}");

Console.WriteLine(
    $"{member2.Name} registered. Status: {registration2.Status}");

registration2.Confirm();
Console.WriteLine(
    $"{member2.Name} confirmed. Status: {registration2.Status}");

Console.WriteLine($"Total registrations: {registrations.Count}");

// BƯỚC 5: Một thành viên check-in
Console.WriteLine($"\n{Separator}");
Console.WriteLine("STEP 5: CHECK-IN");

CheckIn checkIn = CheckIn.Create(
    registration1.Id,
    CheckInMethod.QRCode);

var checkIns = new List<CheckIn> { checkIn };

Console.WriteLine($"Check-in member: {member1.Name}");
Console.WriteLine($"Check-in details: {checkIn.Summary()}");

// BƯỚC 6: Báo cáo tham dự
Console.WriteLine($"\n{Separator}");
Console.WriteLine("STEP 6: ATTENDANCE REPORT");

Console.WriteLine($"Club: {club.Name}");
Console.WriteLine($"Event: {techEvent.Title}");
Console.WriteLine($"Total registrations: {registrations.Count}");
Console.WriteLine($"Total check-ins: {checkIns.Count}");
Console.WriteLine("Registered members:");

foreach (var item in registrations)
{
    Console.WriteLine(
        $"- {item.Member.Name} | Status: {item.Registration.Status}");
}

Console.WriteLine("Checked-in members:");

foreach (var item in registrations)
{
    foreach (var record in checkIns)
    {
        if (item.Registration.Id == record.RegistrationId)
        {
            Console.WriteLine($"- {item.Member.Name}");
        }
    }
}

// BƯỚC 7: Thử vi phạm quy tắc nghiệp vụ
Console.WriteLine($"\n{Separator}");
Console.WriteLine("STEP 7: BUSINESS RULE VALIDATION");

Registration testRegistration =
    Registration.Create(member3.Id, techEvent.Id);

testRegistration.Cancel();

Console.WriteLine(
    $"Registration cancelled. Status: {testRegistration.Status}");

try
{
    testRegistration.Confirm();
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Expected business rule error: {ex.Message}");
}

Console.WriteLine(Separator);
Console.WriteLine("DEMO COMPLETED");
