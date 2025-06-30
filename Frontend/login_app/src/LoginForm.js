import React, { useState } from "react";
import './LoginForm.css';

const LoginForm = () => {
    // State hooks to store the input values
    const [name, setName] = useState("");
    const [password, setPassword] = useState("");
    const [error, setError] = useState("");

    // Handle form submission
    const handleSubmit = (event) => {
        event.preventDefault();

        // Simple validation
        if (name && password) {
            console.log("Login details submitted:", { login: name, password });
            // Optionally clear the fields after submission
            setName("");
            setPassword("");
        } else {
            setError("Please fill out both fields.");
        }
    };

    return (
        <form className="form" onSubmit={handleSubmit}>
            <h1>Login</h1>

            {/* Name Input */}
            <label htmlFor="name">Name</label>
            <input
                type="text"
                id="name"
                value={name}
                onChange={(e) => setName(e.target.value)} // Update state with input value
                required
            />

            {/* Password Input */}
            <label htmlFor="password">Password</label>
            <input
                type="password"
                id="password"
                value={password}
                onChange={(e) => setPassword(e.target.value)} // Update state with input value
                required
            />

            {/* Error Message */}
            {error && <div style={{ color: "red" }}>{error}</div>}

            {/* Submit Button */}
            <button type="submit">Continue</button>
        </form>
    );
};

export default LoginForm;
