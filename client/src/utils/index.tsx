import axios from 'axios';

axios.defaults.baseURL = 'https://localhost:8081/api/';
axios.defaults.headers.common['X-HeCode'] = 'AP0001';

export * from './customhooks/useWindowDimensions';
export * from './ScrollTo';
