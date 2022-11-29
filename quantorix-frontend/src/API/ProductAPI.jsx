import axios from "axios"

export default axios.create({
   baseURL : 'http://localhost:7531/api/Product',
});