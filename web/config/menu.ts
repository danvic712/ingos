export default [
  {
    name: 'Dashboard',
    icon: 'dashboard',
    path: '/dashboard',
    component: './dashboard',
  },
  {
    name: 'Application',
    icon: 'smile',
    path: '/applications',
    routes: [
      {
        path: '/applications',
        redirect: '/applications/overview',
      },
      {
        name: 'Overview',
        path: '/applications/overview',
        component: './application/Overview',
      },
      {
        name: 'Service',
        path: '/applications/services',
        component: './application/service',
      },
    ],
  },
  {
    name: 'Resource',
    icon: 'smile',
    path: '/resources',
    routes: [
      {
        name: 'Workload',
        routes: [
          {
            name: 'Deployment',
            path: '/resources/deployments',
            component: './resource/deployment',
          },
          {
            name: 'Statefulset',
            path: '/resources/statefulsets',
            component: './resource/statefulset',
          },
          {
            name: 'Daemonset',
            path: '/resources/daemonsets',
            component: './resource/daemonset',
          },
        ],
      },
      {
        name: 'Ingress',
        path: '/resources/ingresses',
        component: './resource/ingress',
      },
      {
        name: 'Job',
        path: '/resources/jobs',
        component: './resource/job',
      },
      {
        name: 'Pod',
        path: '/resources/pods',
        component: './resource/pod',
      },
    ],
  },
  {
    name: 'Configuration',
    icon: 'smile',
    path: '/configurations',
    routes: [{}],
  },
  {
    name: 'Storage',
    icon: 'smile',
    path: '/storages',
    routes: [{}],
  },
  {
    name: 'Monitor',
    icon: 'smile',
    path: '/monitors',
    routes: [{}],
  },
  {
    name: 'Workplace',
    icon: 'profile',
    path: '/workplace',
    component: './user/Workplace',
  },
  {
    path: '/',
    redirect: '/dashboard',
  },
  {
    component: './404',
  },
];
