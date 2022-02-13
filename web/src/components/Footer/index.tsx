import { useIntl } from 'umi';
import { DefaultFooter } from '@ant-design/pro-layout';

const Footer: React.FC = () => {
  const intl = useIntl();
  const defaultMessage = intl.formatMessage({
    id: 'app.copyright.produced',
    defaultMessage: 'Danvic Wang',
  });

  const currentYear = new Date().getFullYear();

  return (
    <DefaultFooter
      copyright={`2021 - ${currentYear} ${defaultMessage}, Powered By .NET on Kubernetes & Dapr`}
    />
  );
};

export default Footer;
