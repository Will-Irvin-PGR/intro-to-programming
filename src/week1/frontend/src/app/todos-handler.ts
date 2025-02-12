import { http, delay, HttpResponse } from 'msw';

export const TodosHandler = [
  http.get('http://localhost:1337/todos', async () => {
    await delay(3000);
    return HttpResponse.json([]);
  }),
];
