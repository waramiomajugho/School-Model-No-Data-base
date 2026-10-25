export default function PersonCard({ person }) {
  
  const badgeClass = `role-badge ${person.role.toLowerCase()}`;

  return (
    <div className="person-card">
      <div className="person-info">
        <h3>{person.firstName} {person.lastName}</h3>
        
        <div className="person-details">
          <p><strong>Age:</strong> {person.age}</p>

          {/* Conditional unique fields based on role */}
          {person.role === "Student" && (
            <>
              <p><strong>Enrolment No:</strong> {person.enrolmentNo}</p>
              <p><strong>Year Group:</strong> {person.yearGroup}</p>
            </>
          )}

          {person.role === "Teacher" && (
            <>
              <p><strong>Subject:</strong> {person.subject}</p>
              <p><strong>Salary:</strong> ${person.salary.toLocaleString()}</p>
            </>
          )}

          {person.role === "Principal" && (
            <>
              <p><strong>Office:</strong> {person.officeNumber}</p>
              <p><strong>Start Date:</strong> {person.startDate}</p>
            </>
          )}
        </div>
      </div>

      <span className={badgeClass}>{person.role}</span>
    </div>
  );
}