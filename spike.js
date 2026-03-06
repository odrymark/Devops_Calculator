import http from 'k6/http';
import { check, sleep } from 'k6';

export const options = {
    stages: [
        { duration: '10s', target: 10  },
        { duration: '30s', target: 200 },
        { duration: '10s', target: 0   },
    ],
    thresholds: {
        http_req_failed:   ['rate<0.01'],
        http_req_duration: ['p(95)<500'],
    },
};

export default function () {
    const requests = [
        { url: `${BASE_URL}/api/calculator/add?a=10&b=5`,        expected: 15  },
        { url: `${BASE_URL}/api/calculator/subtract?a=10&b=5`,   expected: 5   },
        { url: `${BASE_URL}/api/calculator/multiply?a=10&b=5`,   expected: 50  },
        { url: `${BASE_URL}/api/calculator/divide?a=10&b=5`,     expected: 2   },
        { url: `${BASE_URL}/api/calculator/factorial?a=5`,       expected: 120 },
        { url: `${BASE_URL}/api/calculator/isprime?a=7`,         expected: true },
    ];

    const req = requests[Math.floor(Math.random() * requests.length)];
    const res = http.get(req.url);

    check(res, {
        'status is 200': (r) => r.status === 200,
        'response time < 500ms': (r) => r.timings.duration < 500,
    });

    sleep(1);
}