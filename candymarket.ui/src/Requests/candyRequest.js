import axios from 'axios';

const baseUrl = 'https://localhost:44337';

const getAllCandy = () => new Promise((resolve, reject) => {
    axios.get(`${baseUrl}/candy`).then(result => resolve(result.data))
    .catch(reject);
});

const whichCandy = id => new Promise((resolve, reject) => {
    axios.get(`${baseUrl}/candy/${id}/`)
        .then(resp => resolve(resp.data))
        .catch(err => console.error(reject));
});

export default { getAllCandy, whichCandy };
