export default [
  {
    name: 'Dashboard',
    path: '/dashboard',
    component: './dashboard',
  },
  {
    name: 'Application',
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
        name: 'Application Details',
        path: '/applications/:appName/details',
        component: './application/detail',
      },
      {
        name: 'Service',
        path: '/applications/services',
        component: './application/service',
      },
      {
        name: 'Edit Service',
        path: '/applications/services/edit',
        component: './application/edit-service',
      },
    ],
  },
  {
    name: 'Resource',
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
    path: '/configurations',
    routes: [{}],
  },
  {
    name: 'Storage',
    path: '/storages',
    routes: [{}],
  },
  {
    name: 'Monitor',
    path: '/monitors',
    routes: [{}],
  },
  {
    name: 'Workplace',
    path: '/workplace',
    component: './user/workplace',
  },
  {
    path: '/login',
    layout: false,
    component: './user/login',
  },
  {
    path: '/exception',
    layout: true,
    routes: [
      {
        name: '500',
        icon: 'smile',
        path: '/exception/500',
        component: './exception/500',
      },
      {
        name: '403',
        icon: 'smile',
        path: '/exception/403',
        component: './exception/403',
      },
    ],
  },
  {
    path: '/',
    redirect: '/dashboard',
  },
  {
    component: './404',
  },
];
