import { useState, useEffect } from 'react';
import { useNavigate, useParams, Link } from 'react-router-dom';
import useDocumentTitle from '../hooks/useDocumentTitle';

export default function PersonForm({ people, setPeople }) {
  const { id } = useParams();
  const navigate = useNavigate();
  const isEditing = Boolean(id);

  
  useDocumentTitle(isEditing ? 'Edit Person - School Management' : 'Add New Person - School Management');

  
  const [formData, setFormData] = useState({
    firstName: '',
    lastName: '',
    dob: '',
    role: 'Student',
    yearGroup: '',
    subject: '',
    salary: ''
  });

  const [errors, setErrors] = useState({});

  
  useEffect(() => {
    if (isEditing) {
      const existingPerson = people.find(p => p.id === id);
      if (existingPerson) {
        setFormData(existingPerson);
      }
    }
  }, [id, isEditing, people]);

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData(prev => ({ ...prev, [name]: value }));
  };

  
  const validate = () => {
    const newErrors = {};

    if (!formData.firstName.trim()) {
      newErrors.firstName = 'First name is required.';
    }
    if (!formData.lastName.trim()) {
      newErrors.lastName = 'Last name is required.';
    }

    if (!formData.dob) {
      newErrors.dob = 'Date of birth is required.';
    } else {
      const birthDate = new Date(formData.dob);
      const today = new Date();
      
      if (birthDate > today) {
        newErrors.dob = 'Date of birth must be in the past.';
      } else {
        // Calculate age
        let age = today.getFullYear() - birthDate.getFullYear();
        const m = today.getMonth() - birthDate.getMonth();
        if (m < 0 || (m === 0 && today.getDate() < birthDate.getDate())) {
          age--;
        }

        if (age < 3 || age > 80) {
          newErrors.dob = 'Calculated age must be between 3 and 80.';
        }
      }
    }

  
    if (formData.role === 'Teacher') {
      if (!formData.subject.trim()) {
        newErrors.subject = 'Subject is required for teachers.';
      }
      if (!formData.salary || Number(formData.salary) <= 0) {
        newErrors.salary = 'Salary must be a positive number.';
      }
    }

    setErrors(newErrors);
    return Object.keys(newErrors).length === 0;
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    
    
    if (!validate()) return;

    if (isEditing) {
      // Update existing record
      setPeople(people.map(p => p.id === id ? { ...formData, id } : p));
    } else {
      // Add new record with a unique ID and immediate state update
      const newPerson = { ...formData, id: Date.now().toString() };
      setPeople([...people, newPerson]);
    }

    // Navigate back to directory
    navigate('/');
  };

  return (
    <div className="form-page-container">
      <h1>{isEditing ? 'Edit Person' : 'Add New Person'}</h1>
      
      <form onSubmit={handleSubmit} className="person-form">
        
        <div className="form-group">
          <label>First Name:</label>
          <input 
            type="text" 
            name="firstName" 
            value={formData.firstName} 
            onChange={handleChange} 
          />
          {errors.firstName && <span className="error-message">{errors.firstName}</span>}
        </div>

        <div className="form-group">
          <label>Last Name:</label>
          <input 
            type="text" 
            name="lastName" 
            value={formData.lastName} 
            onChange={handleChange} 
          />
          {errors.lastName && <span className="error-message">{errors.lastName}</span>}
        </div>

        <div className="form-group">
          <label>Date of Birth:</label>
          <input 
            type="date" 
            name="dob" 
            value={formData.dob} 
            onChange={handleChange} 
          />
          {errors.dob && <span className="error-message">{errors.dob}</span>}
        </div>

        <div className="form-group">
          <label>Role:</label>
          <select 
            name="role" 
            value={formData.role} 
            onChange={handleChange}
          >
            <option value="Student">Student</option>
            <option value="Teacher">Teacher</option>
          </select>
        </div>

        {/* Conditional Field: Student Year Group */}
        {formData.role === 'Student' && (
          <div className="form-group">
            <label>Year Group:</label>
            <input 
              type="text" 
              name="yearGroup" 
              value={formData.yearGroup} 
              onChange={handleChange} 
            />
          </div>
        )}

        {/* Conditional Fields: Teacher Subject and Salary (Frontend Requirement 2) */}
        {formData.role === 'Teacher' && (
          <>
            <div className="form-group">
              <label>Subject:</label>
              <input 
                type="text" 
                name="subject" 
                value={formData.subject} 
                onChange={handleChange} 
              />
              {errors.subject && <span className="error-message">{errors.subject}</span>}
            </div>
            
            <div className="form-group">
              <label>Salary ($):</label>
              <input 
                type="number" 
                name="salary" 
                value={formData.salary} 
                onChange={handleChange} 
              />
              {errors.salary && <span className="error-message">{errors.salary}</span>}
            </div>
          </>
        )}

        <div className="form-actions">
          <button type="submit" className="btn-primary btn-submit">
            {isEditing ? 'Update Person' : 'Save Person'}
          </button>
          <Link to="/" className="btn-secondary">
            Cancel
          </Link>
        </div>

      </form>
    </div>
  );
}
