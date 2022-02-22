export default [
  {
    name: 'Dashboard',
    icon: 'dashboard',
    path: '/dashboard',
    component: './dashboard',
  },
  {
    name: 'Application',
    icon: 'application',
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
        children: [
          {
            name: 'Application Details',
            path: '/applications/:appName/details',
            component: './application/detail',
            hideInMenu: true,
          },
        ],
      },
      {
        name: 'Service',
        path: '/applications/services',
        component: './application/service',
        children: [
          {
            name: 'Edit Service',
            path: '/applications/services/edit',
            component: './application/edit-service',
            hideInMenu: true,
          },
        ],
      },
    ],
  },
  {
    name: 'Resource',
    icon: 'resource',
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
    icon: 'configuration',
    path: '/configurations',
    routes: [{}],
  },
  {
    name: 'Storage',
    icon: 'storage',
    path: '/storages',
    routes: [{}],
  },
  {
    name: 'Monitor',
    icon: 'monitor',
    path: '/monitors',
    routes: [{}],
  },
  {
    name: 'Workplace',
    icon: 'workplace',
    path: '/workplace',
    component: './user/workplace',
  },
];
