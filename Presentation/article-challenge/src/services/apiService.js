import axios from 'axios';

const api = axios.create({baseURL: 'https://localhost:44392/api/v1/' });

export default api;