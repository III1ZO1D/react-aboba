import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import axios from 'axios';

function Autorization() {
    const [login, setLogin] = useState('');
    const [password, setPassword] = useState('');
    const [users, setUsers] = useState([]);
    const [user, setUser] = useState(null);
    
    useEffect(() => {
    axios.get('https://646cd32b7b42c06c3b2c1813.mockapi.io/Users').then((res) => {
    setUsers(res.data);
    }).catch((err) => {
    console.error(err);
    alert('Error fetching users');
    });
    }, []);
    
    const handleLogin = (e) => {
    e.preventDefault();
    const authenticatedUser = users.find((u) => u.login === login && u.password === password);
    if (!authenticatedUser) {
    alert('Incorrect username or password');
    return;
    }
    localStorage.setItem('userId', authenticatedUser.id);
    localStorage.setItem('userLogin', login);
    setUser(authenticatedUser);
    window.location.href = '/';
    };
    
    useEffect(() => {
    document.querySelector('.overlay').style.display = 'block';
    }, []);
    
    return (
    <div className="overlay">
    <div className="Login">
    <h2>Авторизация</h2>
    <Link to="/Registration" className="Link">
        
    <span>Хотите зарегестрироваться?</span>
    </Link>
    
    <div className="login">
    <input placeholder="Логин..." value={login} onChange={(e) => setLogin(e.target.value)} />
    </div>
    <div className="login">
    <input placeholder="Пароль..." value={password} onChange={(e) => setPassword(e.target.value)} />
    </div>
    
    <button className="logBtn" onClick={handleLogin}>
    Войти
    </button>
    
    </div>
    </div>
    );
    }
    export default Autorization;