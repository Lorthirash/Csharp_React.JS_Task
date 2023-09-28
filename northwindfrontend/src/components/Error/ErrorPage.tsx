import React from 'react';
import { Link } from 'react-router-dom';

const ErrorPage = () => {
  return (
    <div className="container text-center mt-5">
      <h1 className="display-4">Oops! This page couldn't be found.</h1>
      <p className="lead">The requested page does not exist. Please check the URL.</p>
      <Link to="/" className="btn btn-primary mt-3">Back to the Home Page</Link>
    </div>
  );
};

export default ErrorPage;
