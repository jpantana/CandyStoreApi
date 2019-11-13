import axios from 'axios';

const baseUrl = 'https://localhost:44337';

const getAllUserCandy = () => new Promise((resolve, reject) => {
    axios.get(`${baseUrl}/usercandy`).then(result => resolve(result.data))
    .catch(reject);
});

const makeTrade = (id, update) => axios.put(`${baseUrl}/${id}/trade`, update);


export default { getAllUserCandy, makeTrade };
