import { useParams, Link } from 'react-router-dom';
import useDocumentTitle from '../hooks/useDocumentTitle';

export default function PersonDetail({ people }) {
  const { id } = useParams();
  const person = people.find(p => p.id === id);

  
  useDocumentTitle(person ? `${person.firstName} ${person.lastName} - Details` : 'Person Not Found');

  if (!person) {
    return (
      <div className="not-found-container">
        <h2>Person Not Found</h2>
        <p>The person with ID "{id}" does not exist in our records.</p>
        <Link to="/" className="btn-secondary">Back to Directory</Link>
      </div>
    );
  }

  return (
    <div className="person-detail-container">
      <h1>{person.firstName} {person.lastName}</h1>
      <p><strong>Role:</strong> {person.role}</p>
      <p><strong>Date of Birth:</strong> {person.dob}</p>
      
      {person.role === 'Student' && (
        <p><strong>Year Group:</strong> {person.yearGroup}</p>
      )}

      {person.role === 'Teacher' && (
        <>
          <p><strong>Subject:</strong> {person.subject}</p>
          <p><strong>Salary:</strong> ${person.salary}</p>
        </>
      )}

      <div className="detail-actions">
        <Link to="/" className="btn-secondary">Back to Directory</Link>
      </div>
    </div>
  );
}