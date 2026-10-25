[ IReportable ] (Interface)
                     │
                     ▼
          [ SchoolMember ] (Abstract Base Class)
          ├── Id, FirstName, LastName, Dob
          ├── FullName { get; } (Computed)
          └── Age { get; } (Computed)
           /         |         \
          ▼          ▼          ▼
     [ Student ] [ Teacher ] [ Principal ]
     (EnrolmentNo) (Salary)  (OfficeNo)
          │          │           │
          └─────┬────┘           │
                │                │
                ▼                ▼
         [ Course ]          [ Department ]
         - Title, Code       - Name
         - Teacher           - HeadTeacher
         - Students List     - Teachers List





Inheritance & Abstraction: The abstract base class SchoolMember handles shared profile data (id, names, dates of birth) and computes properties like FullName and Age. Derived classes (Student, Teacher, Principal) inherit these traits while adding their specific fields.

Polymorphism: Every member overrides a shared Describe() method. They are stored in a single collection (List<SchoolMember>) and looped through to demonstrate dynamic behavior.

Relationships & Domain Models: Department links a head teacher and a collection of teachers, while Course tracks a title, code, assigned teacher, and a managed roster of enrolled students.

Encapsulation & Safety: Private backing fields protect sensitive data and constraints—such as blocking negative salaries or preventing course over-enrolment past capacity limits.

Interfaces & Console App: An IReportable interface powers system reporting across multiple models, all controlled via a clean, text-based console menu loop in Program.cs adhering to strict file-length constraints.