import { useState } from 'react';

export default function PersonCard({ person }) {
  const [isExpanded, setIsExpanded] = useState(false);
  const badgeClass = `role-badge ${person.role.toLowerCase()}`;

  return (
    <div 
      className={`person-card ${isExpanded ? "expanded" : ""}`}
      onClick={() => setIsExpanded(!isExpanded)}
    >
      <div className="person-info">
        <div className="person-header-row">
          <div>
            <h3>{person.firstName} {person.lastName}</h3>
            
            <div className="person-details">
              <p><strong>Age:</strong> {person.age}</p>

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

        {isExpanded && (
          <div className="details-view">
            <p className="details-hint">Click again to collapse details.</p>

            {person.role === "Student" && person.grades && (
              <div>
                <h4 className="grades-title">Course Grades:</h4>
                <ul className="grades-list">
                  {person.grades.map((g, index) => (
                    <li key={index} className="grade-item">
                      <span>{g.course}</span>
                      <strong>{g.grade}</strong>
                    </li>
                  ))}
                </ul>
              </div>
            )}

            {person.role === "Teacher" && (
              <p className="role-info-text">
                <strong>Department Info:</strong> Teaches {person.subject} department curriculum and manages classroom activities.
              </p>
            )}

            {person.role === "Principal" && (
              <p className="role-info-text">
                <strong>Administrative Role:</strong> Oversees school operations, staff performance, and student welfare.
              </p>
            )}
          </div>
        )}
      </div>
    </div>
  );
}