import axios from 'axios';

const baseUrl = 'https://localhost:44337';

const getAllUsers = () => new Promise((resolve, reject) => {
    axios.get(`${baseUrl}/user`).then(result => resolve(result.data))
    .catch(reject);
});

const whoOwnsCandy = id => new Promise((resolve, reject) => {
    axios.get(`${baseUrl}/user/${id}`)
    .then(resp => resolve(resp.data))
    .catch(reject);
});

export default { getAllUsers, whoOwnsCandy };
